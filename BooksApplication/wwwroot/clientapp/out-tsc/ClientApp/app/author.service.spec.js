import { TestBed } from '@angular/core/testing';
import { AuthorService } from './author.service';
describe('AuthorService', function () {
    beforeEach(function () { return TestBed.configureTestingModule({}); });
    it('should be created', function () {
        var service = TestBed.get(AuthorService);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=author.service.spec.js.map