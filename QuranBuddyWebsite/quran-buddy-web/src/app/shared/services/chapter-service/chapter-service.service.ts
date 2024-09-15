import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Chapter } from '../../models/chapter';

@Injectable({
  providedIn: 'root'
})
export class ChapterService {
  private apiUrl = 'http://localhost:5101/api/chapters';

  constructor(private http: HttpClient) {}

  getChapters(): Observable<Chapter[]> {
    return this.http.get<Chapter[]>(`${this.apiUrl}`);
  }

  getChapterById(id: number): Observable<Chapter> {
    return this.http.get<Chapter>(`${this.apiUrl}/by-id/${id}`);
  }

  getChapterByName(name: string): Observable<Chapter[]> {
    return this.http.get<Chapter[]>(`${this.apiUrl}/by-name/${name}`);
  }
}
