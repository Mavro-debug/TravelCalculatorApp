import { TestBed } from '@angular/core/testing';

import { HttpTravelCalculatorService } from './http-travel-calculator.service';

describe('HttpTravelCalculatorService', () => {
  let service: HttpTravelCalculatorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HttpTravelCalculatorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
