import { UUID } from "node:crypto";

export interface Flashcard {
    id: UUID;
    flashcardSetId: string;
    question: string;
    answer: string;
    imageUrl: string;
  }
  