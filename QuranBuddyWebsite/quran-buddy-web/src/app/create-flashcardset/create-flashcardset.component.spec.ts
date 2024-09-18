import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateFlashcardsetComponent } from './create-flashcardset.component';

describe('CreateFlashcardsetComponent', () => {
  let component: CreateFlashcardsetComponent;
  let fixture: ComponentFixture<CreateFlashcardsetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateFlashcardsetComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreateFlashcardsetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
