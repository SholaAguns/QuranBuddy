import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FlashcardSet } from '../../models/flashcardset';

@Injectable({
  providedIn: 'root'
})
export class FlashcardService {
  private baseUrl = 'http://localhost:5000/api/flashcards'; // Replace with your API base URL

  constructor(private http: HttpClient) {}

  getFlashcardSet(flashcardRequest: any): Observable<FlashcardSet> {
    return this.http.post<FlashcardSet>(`${this.baseUrl}`, flashcardRequest);
  }
}
