import { TestBed } from '@angular/core/testing';

import { VerseServiceService } from './verse-service.service';

describe('VerseServiceService', () => {
  let service: VerseServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VerseServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
