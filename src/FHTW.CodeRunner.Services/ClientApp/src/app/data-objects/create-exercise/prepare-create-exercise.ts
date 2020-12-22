import { ProgrammingLanguage } from "../programming-language";
import { QuestionType } from "../question-type";
import { WrittenLanguage } from "../written-language";

export class PrepareCreateExercise {
    id: number;
    programmingLanguageList?: ProgrammingLanguage[];
    writtenLanguageList?: WrittenLanguage[];
    questionTypeList?: QuestionType[];
    
}