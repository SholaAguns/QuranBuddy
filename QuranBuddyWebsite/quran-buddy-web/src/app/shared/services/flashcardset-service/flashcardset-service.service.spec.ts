import { TestBed } from '@angular/core/testing';

import { FlashcardSetService } from './flashcardset-service.service';

describe('FlashcardsetServiceService', () => {
  let service: FlashcardSetService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FlashcardSetService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
