import { TestBed } from '@angular/core/testing';

import { DepartmentsListService } from './departments-list.service';

describe('DepartmentsListService', () => {
  let service: DepartmentsListService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DepartmentsListService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
