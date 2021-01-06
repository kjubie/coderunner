import { Tag } from "../tag";

export class ExerciseTag {
    constructor() {
        this.id = 0;
        this.fkTag = new Tag();
    }

    id: number;
    fkTag: Tag;
}