import { TestBed } from '@angular/core/testing';

import { DepartmentAddService } from './department-add.service';

describe('DepartmentAddService', () => {
  let service: DepartmentAddService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DepartmentAddService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
