import { Room, Client } from "@colyseus/core";
import { GameRoomState } from "./schema/GameRoomState";
import { Vector2Schema } from "./schema/Vector2Schema";

export class GameRoom extends Room<GameRoomState> {
  maxClients = 4;

  onCreate (options: any) {
    console.log("Game Room created!")
    this.setState(new GameRoomState());

    this.onMessage("move", (client, data) => {
      const position = new Vector2Schema(data.position.x, data.position.y);
      const rotation = data.rotation;
      const input = new Vector2Schema(data.input.x, data.input.y);
      this.state.movePlayer(client.sessionId, position, rotation, input);
    });

    this.onMessage("fire", (client, data) => {
      console.log("fire " + data)
      this.broadcast("fire", data);
    })

    this.onMessage("takeDamage", (client, data) => {
      console.log(data)
      const targetId = client.sessionId;
      const targetPlayer = this.state.players.get(targetId);
      const currentHealth = data.currentHealth;
      targetPlayer.currentHealth = currentHealth;
      
      if (data.attackerId) {
        const attackerId = data.attackerId;

        if (targetPlayer.currentHealth <= 0) {
          this.state.killPlayerBySomeone(targetId, attackerId);
        }
      }
      else
      {
        console.log("damage from dead zone!");
        if (targetPlayer.currentHealth <= 0) {
          this.respawn(targetId);
        }
      }
    })
  }

  onJoin (client: Client, options: any) {
    console.log(client.sessionId, "joined!", options);
    this.state.createPlayer(client.sessionId, options.username);
  }

  onLeave (client: Client, consented: boolean) {
    console.log(client.sessionId, "left!");
    this.state.removePlayer(client.sessionId);
  }

  onDispose() {
    console.log("room", this.roomId, "disposing...");
  }

  respawn(targetId: string) {
    const targetPlayer = this.state.players.get(targetId);
    const respawnPositionIndex = this.state.getSpawnPointIndex();
    const respawnPosition = this.state.spawnPoints[respawnPositionIndex];
    this.clients.getById(targetId).send("respawn", respawnPosition);
    targetPlayer.currentHealth = targetPlayer.totalHealth;
  }

}
