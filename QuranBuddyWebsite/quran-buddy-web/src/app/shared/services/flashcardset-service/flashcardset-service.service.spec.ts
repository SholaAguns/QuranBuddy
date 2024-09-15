import { TestBed } from '@angular/core/testing';

import { FlashcardsetServiceService } from './flashcardset-service.service';

describe('FlashcardsetServiceService', () => {
  let service: FlashcardsetServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FlashcardsetServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
