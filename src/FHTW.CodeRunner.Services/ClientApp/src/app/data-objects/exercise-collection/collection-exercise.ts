export class CollectionExercise {
    constructor(id) {
        this.id = id;
        this.version = 0;
        this.writtenLanguage = 0;
        this.programmingLanguage = 0;
    }

    id: number;
    version: number;
    writtenLanguage: number;
    programmingLanguage: number;
}