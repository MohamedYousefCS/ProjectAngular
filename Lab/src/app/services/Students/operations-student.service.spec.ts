import { TestBed } from '@angular/core/testing';

import { OperationsStudentService } from './operations-student.service';

describe('OperationsStudentService', () => {
  let service: OperationsStudentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OperationsStudentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
