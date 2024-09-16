import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FlashcardSet } from '../../models/flashcardset';

@Injectable({
  providedIn: 'root'
})
export class FlashcardSetService {
  private baseUrl = 'http://localhost:5000/api/flashcardset'; // Replace with your API base URL

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
}
