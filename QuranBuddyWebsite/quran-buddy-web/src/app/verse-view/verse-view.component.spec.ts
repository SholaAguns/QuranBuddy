import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VerseViewComponent } from './verse-view.component';

describe('VerseViewComponent', () => {
  let component: VerseViewComponent;
  let fixture: ComponentFixture<VerseViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VerseViewComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(VerseViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
