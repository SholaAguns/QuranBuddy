import { Component } from '@angular/core';
import { FlashcardSet } from '../shared/models/flashcardset';
import { FlashcardSetService } from '../shared/services/flashcardset-service/flashcardset-service.service';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FlashcardSetDeleteRange } from '../shared/requests/flashcardset-requests';
import { UUID } from 'crypto';

@Component({
  selector: 'app-flashcardset-list',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './flashcardset-list.component.html',
  styleUrl: './flashcardset-list.component.scss'
})
export class FlashcardsetListComponent {

  flashcardSets: FlashcardSet[] = [];
  selectedFlashcardSetIds: UUID[] = [];

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

  toggleSelection(flashcardSetId: UUID, event: Event) {
    const inputElement = event.target as HTMLInputElement; // Cast the event target as an HTMLInputElement
    const isSelected = inputElement.checked;

    if (isSelected) {
      // Add the flashcard set ID to the selected array
      this.selectedFlashcardSetIds.push(flashcardSetId);
    } else {
      // Remove the flashcard set ID from the selected array
      this.selectedFlashcardSetIds = this.selectedFlashcardSetIds.filter(id => id !== flashcardSetId);
    }
  }

  bulkDelete() {
    if (this.selectedFlashcardSetIds.length > 0) {
      const flashcardsetRequest: FlashcardSetDeleteRange = {
        ids: this.selectedFlashcardSetIds,
      };
      this.flashcardSetService.deleteFlashcardSetRange(flashcardsetRequest).subscribe(
        () => {
          console.log('Selected flashcard sets deleted');
          window.location.reload();
          this.fetchFlashcardsets();
          // Clear the selected flashcard set IDs
          this.selectedFlashcardSetIds = [];
        },
        error => {
          console.error('Error deleting selected flashcard sets', error);
        }
      );
    }
  }
}
