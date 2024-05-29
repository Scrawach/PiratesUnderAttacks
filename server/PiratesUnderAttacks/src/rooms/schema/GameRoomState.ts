import { Schema, MapSchema, type } from "@colyseus/schema";
import { PlayerSchema } from "./PlayerSchema";
import { Vector2Schema } from "./Vector2Schema";

export class GameRoomState extends Schema {

  @type({map: PlayerSchema}) players = new MapSchema<PlayerSchema>();

  availableSkinIds = new Set<number>([0, 1]);

  constructor() {
    super();
  }

  createPlayer(sessionId: string, username: string) : PlayerSchema {
    const spawnPoint = this.getSpawnPoint();
    const skinId = this.getRandomSkinId();
    const player = new PlayerSchema(username, spawnPoint, skinId, 0);
    this.players.set(sessionId, player);
    return player;
  }

  movePlayer(sessionId: string, position: Vector2Schema, rotation: number, input: Vector2Schema) {
    const player = this.players.get(sessionId);
    player.position = position;
    player.rotation = rotation;
    player.input = input;
  }

  removePlayer(sessionId: string) {
    if (this.players.has(sessionId)) {
      const player = this.players.get(sessionId);
      this.availableSkinIds.add(player.skinId);
      this.players.delete(sessionId);
    }
  }

  killPlayerBySomeone(killedId: string, attackerId: string) {
    const attackerPlayer = this.players.get(attackerId);
    attackerPlayer.score += 1;
    console.log(`${attackerId} kill ${killedId}!`);
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
