import { Schema, MapSchema, type } from "@colyseus/schema";
import { PlayerSchema } from "./PlayerSchema";
import { Vector2Schema } from "./Vector2Schema";

export class GameRoomState extends Schema {

  @type({map: PlayerSchema}) players = new MapSchema<PlayerSchema>();

  availableSkinIds = new Set<number>();

  constructor() {
    super();
    this.availableSkinIds.add(0);
    this.availableSkinIds.add(1);
  }

  createPlayer(sessionId: string, username: string) : PlayerSchema {
    const spawnPoint = this.getSpawnPoint();
    const skinId = this.getRandomSkinId();
    const player = new PlayerSchema(username, spawnPoint, skinId, 0);
    this.players.set(sessionId, player);
    return player;
  }

  removePlayer(sessionId: string) {
    if (this.players.has(sessionId)) {
      this.players.delete(sessionId);
    }
  }

  getSpawnPoint() : Vector2Schema {
    return new Vector2Schema(0, 0);
  }

  getRandomSkinId() : number {
    if (this.availableSkinIds.size < 1)
      return 0;

    var iterator = this.availableSkinIds.values();
    var first = iterator.next();
    var value = first.value
    this.availableSkinIds.delete(value)
    return value;
  }
  
}
