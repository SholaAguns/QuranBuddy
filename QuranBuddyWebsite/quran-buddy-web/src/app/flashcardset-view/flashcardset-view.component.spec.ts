import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlashcardsetViewComponent } from './flashcardset-view.component';

describe('FlashcardsetViewComponent', () => {
  let component: FlashcardsetViewComponent;
  let fixture: ComponentFixture<FlashcardsetViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FlashcardsetViewComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FlashcardsetViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
