import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Verse } from '../../models/verse';

@Injectable({
  providedIn: 'root'
})
export class VerseService {
  private apiUrl = 'https://your-api-url.com/api/verses';

  constructor(private http: HttpClient) {}

  getVersesByChapterId(id: number): Observable<Verse[]> {
    return this.http.get<Verse[]>(`${this.apiUrl}/by-chapter-id/${id}`);
  }

  getVerseById(id: number): Observable<Verse> {
    return this.http.get<Verse>(`${this.apiUrl}/by-id/${id}`);
  }
}
