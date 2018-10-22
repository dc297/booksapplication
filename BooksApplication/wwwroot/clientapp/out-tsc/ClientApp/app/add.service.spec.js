import { TestBed } from '@angular/core/testing';
import { AddService } from './add.service';
describe('AddService', function () {
    beforeEach(function () { return TestBed.configureTestingModule({}); });
    it('should be created', function () {
        var service = TestBed.get(AddService);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=add.service.spec.js.map