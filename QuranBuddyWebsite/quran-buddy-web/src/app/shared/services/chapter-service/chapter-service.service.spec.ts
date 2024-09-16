import { TestBed } from '@angular/core/testing';

import { ChapterService } from './chapter-service.service';

describe('ChapterServiceService', () => {
  let service: ChapterService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ChapterService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
