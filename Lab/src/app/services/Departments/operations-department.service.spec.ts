import { TestBed } from '@angular/core/testing';

import { OperationsDepartmentService } from './operations-department.service';

describe('OperationsDepartmentService', () => {
  let service: OperationsDepartmentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OperationsDepartmentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
