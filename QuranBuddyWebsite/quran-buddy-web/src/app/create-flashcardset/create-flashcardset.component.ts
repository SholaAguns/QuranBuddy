import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators, FormArray, FormsModule } from '@angular/forms';
import { FlashcardSet } from '../shared/models/flashcardset';
import { FlashcardService } from '../shared/services/flashcard-service/flashcard-service.service';
import { Router, RouterModule } from '@angular/router';
import { FlashcardRequest } from '../shared/requests/flashcard-requests';

@Component({
  selector: 'app-create-flashcardset',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule, FormsModule],
  templateUrl: './create-flashcardset.component.html',
  styleUrl: './create-flashcardset.component.scss'
})
export class CreateFlashcardsetComponent {
  newFlashcardSet!: FlashcardSet;
  flashcardSetRequestForm!: FormGroup;
  selectedRequestType: string = '';

  flashcardTypes = [
    { label: 'Quran', value: 'Quran' },

  ];
  
  requestTypes = [
    { label: 'Default', value: 'default' },
    { label: 'By Range', value: 'byRange' },
    { label: 'By IDs', value: 'byIds' },
    { label: 'By Names', value: 'byNames' }
  ];

  constructor(private flashcardService: FlashcardService, private formBuilder: FormBuilder,  private router: Router) {

    this.flashcardSetRequestForm = this.formBuilder.group({});
  }

  get idList(): FormArray {
    return this.flashcardSetRequestForm.get('idList') as FormArray;
  }

  loadRequestForm() {
    switch (this.selectedRequestType) {
      case 'default':
        this.flashcardSetRequestForm = this.formBuilder.group({
          amount: ['', [Validators.required, Validators.min(3)]],
          type: ['', Validators.required]
        });
        break;
      
      case 'byRange':
        this.flashcardSetRequestForm = this.formBuilder.group({
          amount: ['', [Validators.required, Validators.min(3)]],
          type: ['', Validators.required],
          rangeStart: ['', Validators.required],
          rangeEnd: ['', Validators.required]
        });
        break;

      case 'byIds':
        this.flashcardSetRequestForm = this.formBuilder.group({
          amount: ['', [Validators.required, Validators.min(3)]],
          type: ['', Validators.required],
          idList: this.formBuilder.array([this.createIdFormControl()])
        });
        break;

      case 'byNames':
        this.flashcardSetRequestForm = this.formBuilder.group({
          amount: ['', [Validators.required, Validators.min(3)]],
          type: ['', Validators.required],
          idList: this.formBuilder.array([this.createIdFormControl()])
        });
        break;

      default:
        this.flashcardSetRequestForm = this.formBuilder.group({});
        break;
    }
  }

  createIdFormControl(): FormGroup {
    return this.formBuilder.group({
      id: ['', Validators.required]
    });
  }


  addIdField() {
    (this.flashcardSetRequestForm.get('idList') as FormArray).push(this.createIdFormControl());
  }

  removeIdField(index: number) {
    (this.flashcardSetRequestForm.get('idList') as FormArray).removeAt(index);
  }
  

  createFlashcardSet() {
    if (this.flashcardSetRequestForm.valid) {
      const requestModel = this.flashcardSetRequestForm.value;
      let requestObservable;

      switch (this.selectedRequestType) {
        case 'default':
          requestObservable = this.flashcardService.getFlashcardSet(requestModel);
          break;
        
        case 'byRange':
          requestObservable = this.flashcardService.getFlashcardSetByRange(requestModel);
          break;
  
        case 'byIds':
          requestObservable = this.flashcardService.getFlashcardSetByIds(requestModel);
          break;
  
        case 'byNames':
          requestObservable = this.flashcardService.getFlashcardSetByNames(requestModel);
          break;
  
        default:
          console.error('Invalid request type');
          return;
      }

      requestObservable.subscribe(
        (response: FlashcardSet) => {
          this.newFlashcardSet = response;
          console.log('Flashcard set created', response);
          this.router.navigate(['/flashcardset-view'], { state: { flashcardSet: this.newFlashcardSet } });
        },
        (error) => {
          console.error('Error creating flashcard set', error);
        }
      );
    }
  } 
}
