import { Component, Input } from '@angular/core';
import { FlashcardSet } from '../shared/models/flashcardset';
import { CommonModule } from '@angular/common';
import { FormArray, FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { FlashcardSetService } from '../shared/services/flashcardset-service/flashcardset-service.service';
import { FlashcardSetAnswers } from '../shared/requests/flashcardset-requests';
import { ActivatedRoute, RouterModule } from '@angular/router';

@Component({
  selector: 'app-flashcardset-view',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule],
  templateUrl: './flashcardset-view.component.html',
  styleUrl: './flashcardset-view.component.scss'
})
export class FlashcardsetViewComponent {
  flashcardSet!: FlashcardSet;
  flashcardsForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private flashcardSetService: FlashcardSetService,
    private route: ActivatedRoute,
  ) {}

  ngOnInit(): void {
    const flashcardSetId = this.route.snapshot.paramMap.get('id');
    if (flashcardSetId) {
      this.flashcardSetService.getFlashcardSetById(flashcardSetId).subscribe((flashcardSet) => {
        this.flashcardSet = flashcardSet;
        this.initializeForm();
      });
    
  }
}

  initializeForm() {
    this.flashcardsForm = this.formBuilder.group({
      flashcards: this.formBuilder.array(this.flashcardSet.flashcards.map(card => this.formBuilder.group({
        question: [card.question],
        answer: [''] 
      })))
    });
  }

  get flashcards() {
    return this.flashcardsForm.get('flashcards') as FormArray;
  }

  setAnswers() {
    if (this.flashcardsForm.valid) {
      const answers = this.flashcardsForm.value.flashcards.map((flashcard: any) => flashcard.answer);
      const flashcardsetRequest: FlashcardSetAnswers = {
        id: this.flashcardSet.id,
        userAnswers: answers
      };
      this.flashcardSetService.setFlashcardSetAnwsers(flashcardsetRequest).subscribe(
        (response: FlashcardSet) => {
          console.log('Answers updated successfully', response);
          window.location.reload();
        },
        (error) => {
          console.error('Error updating answers' + flashcardsetRequest.userAnswers, error);
        }
      );
    }
  }

}
