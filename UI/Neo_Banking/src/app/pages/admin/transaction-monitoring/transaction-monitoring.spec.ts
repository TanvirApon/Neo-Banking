import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransactionMonitoring } from './transaction-monitoring';

describe('TransactionMonitoring', () => {
  let component: TransactionMonitoring;
  let fixture: ComponentFixture<TransactionMonitoring>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TransactionMonitoring]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TransactionMonitoring);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
