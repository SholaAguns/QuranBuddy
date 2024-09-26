import { UUID } from "node:crypto";
import { Flashcard } from "./flashcard";

export interface FlashcardSet {
    id: UUID;
    name: string;
    type: string;
    flashcards: Flashcard[];
    flashcardAmount: number;
    userAnswers: string[];
    report: boolean[];
  }
  