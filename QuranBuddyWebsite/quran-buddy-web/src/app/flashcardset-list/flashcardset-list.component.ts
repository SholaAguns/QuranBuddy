import { Component } from '@angular/core';
import { FlashcardSet } from '../shared/models/flashcardset';
import { FlashcardSetService } from '../shared/services/flashcardset-service/flashcardset-service.service';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-flashcardset-list',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './flashcardset-list.component.html',
  styleUrl: './flashcardset-list.component.scss'
})
export class FlashcardsetListComponent {

  flashcardSets: FlashcardSet[] = [];

  constructor(private flashcardSetService: FlashcardSetService) {}

  ngOnInit() {
    this.fetchFlashcardsets();
  }

  fetchFlashcardsets() {
    this.flashcardSetService.getFlashcardSets().subscribe(
      (data: FlashcardSet[]) => {
        this.flashcardSets = data;
      },
      error => {
        console.error('Error fetching flashcardsets', error);
      }
    );
  }
}
