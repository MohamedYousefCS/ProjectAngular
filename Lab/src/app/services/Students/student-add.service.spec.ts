import { TestBed } from '@angular/core/testing';

import { StudentAddService } from './student-add.service';

describe('StudentAddService', () => {
  let service: StudentAddService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StudentAddService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
