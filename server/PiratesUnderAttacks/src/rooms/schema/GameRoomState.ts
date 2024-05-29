import { Schema, MapSchema, type } from "@colyseus/schema";
import { PlayerSchema } from "./PlayerSchema";
import { Vector2Schema } from "./Vector2Schema";

export class GameRoomState extends Schema {

  @type({map: PlayerSchema}) players = new MapSchema<PlayerSchema>();

  createPlayer(sessionId: string, username: string) : PlayerSchema {
    const spawnPoint = this.getSpawnPoint();
    const skinId = this.getRandomSkinId();
    const player = new PlayerSchema(username, spawnPoint, skinId, 0);
    this.players.set(sessionId, player);
    return player;
  }

  getSpawnPoint() : Vector2Schema {
    return new Vector2Schema(0, 0);
  }

  getRandomSkinId() : number {
    return 0;
  }
  
}
