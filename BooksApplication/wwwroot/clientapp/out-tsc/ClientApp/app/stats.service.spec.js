import { TestBed } from '@angular/core/testing';
import { StatsService } from './stats.service';
describe('StatsService', function () {
    beforeEach(function () { return TestBed.configureTestingModule({}); });
    it('should be created', function () {
        var service = TestBed.get(StatsService);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=stats.service.spec.js.map