import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators, FormArray, FormsModule } from '@angular/forms';
import { FlashcardSet } from '../shared/models/flashcardset';
import { FlashcardService } from '../shared/services/flashcard-service/flashcard-service.service';
import { Router, RouterModule } from '@angular/router';
import { FlashcardRequest, FlashcardRequestByIds, FlashcardRequestByNames, FlashcardRequestByRange } from '../shared/requests/flashcard-requests';
import { ChapterService } from '../shared/services/chapter-service/chapter-service.service';
import { Chapter } from '../shared/models/chapter';
import { rangeValidator } from '../shared/models/validations';

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
  chapters: Chapter[] = [];

  flashcardTypes = [
    { label: 'Quran', value: 'Quran' }
  ];

  requestTypes = [
    { label: 'Default', value: 'default' },
    { label: 'By Range', value: 'byRange' },
    { label: 'By IDs', value: 'byIds' }
  ];

  constructor(
    private flashcardService: FlashcardService, 
    private chapterService: ChapterService, 
    private formBuilder: FormBuilder,  
    private router: Router
  ) {
    this.flashcardSetRequestForm = this.formBuilder.group({});
  }

  ngOnInit() {
    this.fetchChapters();
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
      
      /*case 'byRange':
        this.flashcardSetRequestForm = this.formBuilder.group({
          amount: ['', [Validators.required, Validators.min(3)]],
          type: ['', Validators.required],
          rangeStart: ['', Validators.required],
          rangeEnd: ['', Validators.required]
        } , { validators: rangeValidator() });
        break; */

      case 'byRange':
        this.flashcardSetRequestForm = this.formBuilder.group({
          amount: ['', [Validators.required, Validators.min(3)]],
          type: ['', Validators.required],
          rangeStart: ['', Validators.required],
          rangeEnd: ['', Validators.required]
        }, { validators: rangeValidator() });
        break;


      case 'byIds':
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

  fetchChapters() {
    this.chapterService.getChapters().subscribe(
      (data: Chapter[]) => {
        this.chapters = data;
      },
      error => {
        console.error('Error fetching chapters', error);
      }
    );
  }

  createFlashcardSet() {
    if (this.flashcardSetRequestForm.valid) {
      //const requestModel = this.flashcardSetRequestForm.value;
      const formValue = this.flashcardSetRequestForm.value;
      let requestModel: FlashcardRequest | FlashcardRequestByRange | FlashcardRequestByIds | FlashcardRequestByNames;


      let requestObservable;

      switch (this.selectedRequestType) {
        case 'default':
          requestModel = {
            amount: formValue.amount,
            type: formValue.type
          } as FlashcardRequest;
          requestObservable = this.flashcardService.getFlashcardSet(requestModel as FlashcardRequest);
          break;
        
        case 'byRange':
          requestModel = {
            amount: formValue.amount,
            type: formValue.type,
            rangeStart: formValue.rangeStart,
            rangeEnd: formValue.rangeEnd
          } as FlashcardRequestByRange;
          requestObservable = this.flashcardService.getFlashcardSetByRange(requestModel as FlashcardRequestByRange);
          break;
  
        case 'byIds':
          requestModel = {
            amount: formValue.amount,
            type: formValue.type,
            idList: formValue.idList.map((item: { id: string }) => Number(item.id))
          } as FlashcardRequestByIds;
          requestObservable = this.flashcardService.getFlashcardSetByIds(requestModel as FlashcardRequestByIds);
          break;
  
        default:
          console.error('Invalid request type');
          return;
      }

      requestObservable.subscribe(
        (response: FlashcardSet) => {
          this.newFlashcardSet = response;
          console.log('Flashcard set created', response);
          //this.router.navigate(['/flashcardset-view'], { state: { flashcardSet: this.newFlashcardSet } });
          this.router.navigate(['/flashcardset-view', this.newFlashcardSet.id]);

        },
        (error) => {
          console.error('Error creating flashcard set', error);
        }
      );
    }
  }
}
