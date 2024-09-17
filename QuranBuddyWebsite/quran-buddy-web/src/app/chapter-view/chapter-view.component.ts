import { Component, Input } from '@angular/core';
import { Chapter } from '../shared/models/chapter';
import { Verse } from '../shared/models/verse';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { ChapterService } from '../shared/services/chapter-service/chapter-service.service';
import { VerseService } from '../shared/services/verse-service/verse-service.service';
import { VerseViewComponent } from '../verse-view/verse-view.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-chapter-view',
  standalone: true,
  imports: [VerseViewComponent, RouterModule, CommonModule],
  templateUrl: './chapter-view.component.html',
  styleUrl: './chapter-view.component.scss'
})
export class ChapterViewComponent {

  public chapter!: Chapter;
  public verses!: Verse[];

  constructor(
    private route: ActivatedRoute,
    private chapterService: ChapterService,
    private verseService: VerseService
  ) {}


  

  ngOnInit(): void {
    const chapterId = this.route.snapshot.paramMap.get('id');
    if (chapterId) {
      this.chapterService.getChapterById(+chapterId).subscribe((chapter) => {
        this.chapter = chapter; 
      });
      this.verseService.getVersesByChapterId(+chapterId).subscribe((verses) => {
        this.verses = verses; 
      });
    }
  }



}
