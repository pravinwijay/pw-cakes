import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VoirCatalogueComponent } from './voir-catalogue.component';

describe('VoirCatalogueComponent', () => {
  let component: VoirCatalogueComponent;
  let fixture: ComponentFixture<VoirCatalogueComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [VoirCatalogueComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VoirCatalogueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
