export class ExerciseHeader {
    constructor() {
        this.id = 0;
    }

    id: number;
    fullTitle: string;
    shortTitle: string;
    introduction: string;
    templateParam: string;
    templateParamLiftFlag: boolean;
    twigAllFlag: boolean; 
}