import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AjoutCatalogueComponent } from './ajout-catalogue.component';

describe('AjoutCatalogueComponent', () => {
  let component: AjoutCatalogueComponent;
  let fixture: ComponentFixture<AjoutCatalogueComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AjoutCatalogueComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AjoutCatalogueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
