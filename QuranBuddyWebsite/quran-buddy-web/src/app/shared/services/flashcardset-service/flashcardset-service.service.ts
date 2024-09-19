import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FlashcardSet } from '../../models/flashcardset';
import { FlashcardSetAnswers, FlashcardSetUpdateName } from '../../requests/flashcardset-requests';

@Injectable({
  providedIn: 'root'
})
export class FlashcardSetService {
  private baseUrl = 'http://localhost:5101/api/flashcardset'; // Replace with your API base URL

  constructor(private http: HttpClient) {}

  getFlashcardSets(): Observable<FlashcardSet[]> {
    return this.http.get<FlashcardSet[]>(`${this.baseUrl}`);
  }

  getFlashcardSetById(id: string): Observable<FlashcardSet> {
    return this.http.get<FlashcardSet>(`${this.baseUrl}/by-id/${id}`);
  }

  getFlashcardSetByName(name: string): Observable<FlashcardSet> {
    return this.http.get<FlashcardSet>(`${this.baseUrl}/by-name/${name}`);
  }

  updateFlashcardSetName(flashcardsetRequest: FlashcardSetUpdateName): Observable<FlashcardSet> {
    return this.http.put<FlashcardSet>(`${this.baseUrl}/update-name`, flashcardsetRequest);
  }

  setFlashcardSetAnwsers(flashcardsetRequest: FlashcardSetAnswers): Observable<FlashcardSet> {
    return this.http.post<FlashcardSet>(`${this.baseUrl}/set-answers`, flashcardsetRequest);
  }
}
