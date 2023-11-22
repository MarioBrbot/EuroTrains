import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookTrainsComponent } from './book-trains.component';

describe('BookTrainsComponent', () => {
  let component: BookTrainsComponent;
  let fixture: ComponentFixture<BookTrainsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BookTrainsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BookTrainsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
