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

}
