import { TestBed } from '@angular/core/testing';

import { ApiUrlService } from './apiservice.service';

describe('ApiserviceService', () => {
  let service: ApiUrlService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApiUrlService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
