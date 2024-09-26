import { UUID } from "node:crypto";

export interface FlashcardSetAnswers {
    id: UUID;
    userAnswers: string[];

}

export interface FlashcardSetUpdateName {
    id: UUID;
    name: string;

}