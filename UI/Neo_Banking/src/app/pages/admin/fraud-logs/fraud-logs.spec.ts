import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FraudLogs } from './fraud-logs';

describe('FraudLogs', () => {
  let component: FraudLogs;
  let fixture: ComponentFixture<FraudLogs>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FraudLogs]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FraudLogs);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
