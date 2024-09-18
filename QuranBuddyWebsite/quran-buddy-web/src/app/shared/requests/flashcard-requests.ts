export interface FlashcardRequest {
    amount: number;
    type: string;

}

export interface FlashcardRequestByRange {
    amount: number;
    type: string;
    rangeStart: number;
    rangeEnd: number;

}

export interface FlashcardRequestByIds {
    amount: number;
    type: string;
    idList: number[];

}

export interface FlashcardRequestByNames {
    amount: number;
    type: string;
    idList: number[];

}