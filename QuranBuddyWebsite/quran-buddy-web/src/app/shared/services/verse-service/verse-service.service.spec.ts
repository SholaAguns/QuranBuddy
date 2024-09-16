import { TestBed } from '@angular/core/testing';

import { VerseService } from './verse-service.service';

describe('VerseServiceService', () => {
  let service: VerseService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VerseService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
