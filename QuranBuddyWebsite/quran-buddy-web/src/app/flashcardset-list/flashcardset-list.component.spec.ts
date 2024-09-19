import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlashcardsetListComponent } from './flashcardset-list.component';

describe('FlashcardsetListComponent', () => {
  let component: FlashcardsetListComponent;
  let fixture: ComponentFixture<FlashcardsetListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FlashcardsetListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FlashcardsetListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
