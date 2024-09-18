import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FlashcardSet } from '../../models/flashcardset';
import { FlashcardRequest, FlashcardRequestByIds, FlashcardRequestByNames, FlashcardRequestByRange } from '../../requests/flashcard-requests';

@Injectable({
  providedIn: 'root'
})
export class FlashcardService {
  private baseUrl = 'http://localhost:5101/api/flashcards'; 

  constructor(private http: HttpClient) {}

  getFlashcardSet(flashcardRequest: FlashcardRequest): Observable<FlashcardSet> {
    return this.http.post<FlashcardSet>(`${this.baseUrl}`, flashcardRequest);
  }

  getFlashcardSetByRange(flashcardRequest: FlashcardRequestByRange): Observable<FlashcardSet> {
    return this.http.post<FlashcardSet>(`${this.baseUrl}`, flashcardRequest);
  }

  getFlashcardSetByIds(flashcardRequest: FlashcardRequestByIds): Observable<FlashcardSet> {
    return this.http.post<FlashcardSet>(`${this.baseUrl}`, flashcardRequest);
  }

  getFlashcardSetByNames(flashcardRequest: FlashcardRequestByNames): Observable<FlashcardSet> {
    return this.http.post<FlashcardSet>(`${this.baseUrl}`, flashcardRequest);
  }
}
