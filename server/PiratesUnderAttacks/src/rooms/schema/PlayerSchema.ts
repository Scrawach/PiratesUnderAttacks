import { Schema, type } from "@colyseus/schema";
import { Vector2Schema } from "./Vector2Schema";

export class PlayerSchema extends Schema {
  @type("string") username: string;
  @type(Vector2Schema) position: Vector2Schema;
  @type("float32") rotation: number;
  @type(Vector2Schema) input: Vector2Schema;
  @type("uint8") skinId: number;
  @type("uint16") score: number;
  @type("uint8") currentHealth: number = 100;
  @type("uint8") totalHealth: number = 100;

  constructor(username: string, position: Vector2Schema, angle: number, skinId: number, score: number) {
    super();
    this.username = username;
    this.position = position;
    this.rotation = angle;
    this.skinId = skinId;
    this.score = score;
  }

  addScore(count: number) {
    this.score += count;
  }
}