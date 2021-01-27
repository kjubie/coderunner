import { Author } from "../author";
import { WrittenLanguage } from "../written-language";

export class ImportCollection {

    constructor() {
        // this.writtenLanguage = new WrittenLanguage;
    }

    id: number;
    title: string;
    user: Author;
    writtenLanguage: WrittenLanguage;
    base64XmlString: string;
}