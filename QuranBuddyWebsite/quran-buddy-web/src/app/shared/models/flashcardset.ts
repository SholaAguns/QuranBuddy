import { Flashcard } from "./flashcard";

export interface FlashcardSet {
    id: string;
    name: string;
    type: string;
    flashcards: Flashcard[];
    flashcardAmount: number;
    userAnswers: string[];
    report: boolean[];
  }
  