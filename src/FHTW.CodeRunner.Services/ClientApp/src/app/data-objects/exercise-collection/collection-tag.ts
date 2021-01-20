import { Tag } from "../tag";

export class CollectionTag {
    constructor() {
        this.id = 0;
        this.tag = new Tag();
    }

    id: number;
    tag: Tag;
}