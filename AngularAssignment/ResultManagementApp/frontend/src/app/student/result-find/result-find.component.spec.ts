import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResultFindComponent } from './result-find.component';

describe('ResultFindComponent', () => {
  let component: ResultFindComponent;
  let fixture: ComponentFixture<ResultFindComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResultFindComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ResultFindComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
