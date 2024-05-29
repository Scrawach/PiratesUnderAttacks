import { Room, Client } from "@colyseus/core";
import { GameRoomState } from "./schema/GameRoomState";

export class GameRoom extends Room<GameRoomState> {
  maxClients = 4;

  onCreate (options: any) {
    console.log("Game Room created!")
    this.setState(new GameRoomState());

    this.onMessage("move", (client, data) => {
      console.log(data);
    });
  }

  onJoin (client: Client, options: any) {
    console.log(client.sessionId, "joined!", options);
    this.state.createPlayer(client.sessionId, options.username);
  }

  onLeave (client: Client, consented: boolean) {
    console.log(client.sessionId, "left!");
  }

  onDispose() {
    console.log("room", this.roomId, "disposing...");
  }

}
