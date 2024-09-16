import { Component } from '@angular/core';
import { MatSelectModule } from '@angular/material/select';
import { MatOptionModule } from '@angular/material/core';
import { Chapter } from '../shared/models/chapter';
import { ChapterService } from '../shared/services/chapter-service/chapter-service.service';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';



@Component({
  selector: 'app-chapter-list',
  standalone: true,
  imports: [MatSelectModule, MatOptionModule, CommonModule ],
  templateUrl: './chapter-list.component.html',
  styleUrl: './chapter-list.component.scss'
})
export class ChapterListComponent {
  chapters: Chapter[] = [];

  constructor(private chapterService: ChapterService) {}

  ngOnInit() {
    this.fetchChapters();
  }

  fetchChapters() {
    this.chapterService.getChapters().subscribe(
      (data: Chapter[]) => {
        this.chapters = data;
      },
      error => {
        console.error('Error fetching transfers', error);
      }
    );
  }
  
}
