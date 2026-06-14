
'use strict';

(function initNavbar() {
    const nav = document.getElementById('mainNav');
    const hamburger = document.getElementById('hamburgerBtn');
    const mobileMenu = document.getElementById('mobileMenu');

    if (!nav) return;

    window.addEventListener('scroll', () => {
        nav.classList.toggle('scrolled', window.scrollY > 20);
    }, { passive: true });

    if (hamburger && mobileMenu) {
        hamburger.addEventListener('click', () => {
            const isOpen = mobileMenu.classList.toggle('open');
            hamburger.classList.toggle('open', isOpen);
            hamburger.setAttribute('aria-expanded', String(isOpen));
            document.body.style.overflow = isOpen ? 'hidden' : '';
        });
    }

    mobileMenu?.querySelectorAll('a').forEach(link => {
        link.addEventListener('click', () => {
            mobileMenu.classList.remove('open');
            hamburger?.classList.remove('open');
            document.body.style.overflow = '';
        });
    });
})();

(function initScrollReveal() {
    const els = document.querySelectorAll('.reveal');
    if (!els.length) return;

    const io = new IntersectionObserver((entries) => {
        entries.forEach(e => {
            if (e.isIntersecting) {
                e.target.classList.add('revealed');
                io.unobserve(e.target);
            }
        });
    }, { threshold: 0.12, rootMargin: '0px 0px -40px 0px' });

    els.forEach(el => io.observe(el));
})();

(function initLightbox() {
    const lightbox = document.getElementById('lightbox');
    if (!lightbox) return;

    const lightboxImg = lightbox.querySelector('.lightbox-img');
    const lightboxCaption = lightbox.querySelector('.lightbox-caption');
    const btnClose = lightbox.querySelector('.lightbox-close');
    const btnPrev = lightbox.querySelector('.lightbox-prev');
    const btnNext = lightbox.querySelector('.lightbox-next');

    let images = [];
    let currentIdx = 0;

    function openLightbox(idx) {
        currentIdx = idx;
        const img = images[idx];
        lightboxImg.src = img.dataset.full || img.src;
        lightboxImg.alt = img.alt;
        if (lightboxCaption) lightboxCaption.textContent = img.getAttribute('data-caption') || img.alt || '';
        lightbox.classList.add('open');
        document.body.style.overflow = 'hidden';
        lightbox.focus();
    }

    function closeLightbox() {
        lightbox.classList.remove('open');
        document.body.style.overflow = '';
    }

    function navigate(dir) {
        currentIdx = (currentIdx + dir + images.length) % images.length;
        openLightbox(currentIdx);
    }

    document.querySelectorAll('[data-lightbox]').forEach((item, i) => {
        const img = item.querySelector('img');
        if (img) {
            images.push(img);
            item.addEventListener('click', () => openLightbox(i));
            item.setAttribute('role', 'button');
            item.setAttribute('tabindex', '0');
            item.addEventListener('keydown', e => {
                if (e.key === 'Enter' || e.key === ' ') { e.preventDefault(); openLightbox(i); }
            });
        }
    });

    btnClose?.addEventListener('click', closeLightbox);
    btnPrev?.addEventListener('click', () => navigate(-1));
    btnNext?.addEventListener('click', () => navigate(1));

    lightbox.addEventListener('keydown', e => {
        if (e.key === 'Escape') closeLightbox();
        if (e.key === 'ArrowLeft') navigate(-1);
        if (e.key === 'ArrowRight') navigate(1);
    });

    lightbox.addEventListener('click', e => {
        if (e.target === lightbox) closeLightbox();
    });
})();

(function initGalleryFilters() {
    const filterBtns = document.querySelectorAll('.filter-btn');
    const galleryItems = document.querySelectorAll('.masonry-item');
    if (!filterBtns.length) return;

    filterBtns.forEach(btn => {
        btn.addEventListener('click', () => {
            filterBtns.forEach(b => b.classList.remove('active'));
            btn.classList.add('active');

            const category = btn.dataset.filter;

            galleryItems.forEach(item => {
                const show = category === 'all' || item.dataset.category === category;
                item.style.display = show ? 'block' : 'none';
            });
        });
    });
})();

(function initFormValidation() {
    document.querySelectorAll('form[data-validate]').forEach(form => {
        const inputs = form.querySelectorAll('[required], [data-rule]');

        function validateField(field) {
            const errorEl = document.getElementById(field.id + '-error');
            let msg = '';

            if (field.required && !field.value.trim()) {
                msg = 'To pole jest wymagane.';
            } else if (field.type === 'email' && field.value && !/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(field.value)) {
                msg = 'Podaj prawidłowy adres e-mail.';
            } else if (field.dataset.minlength && field.value.length < parseInt(field.dataset.minlength)) {
                msg = `Minimalna długość: ${field.dataset.minlength} znaków.`;
            } else if (field.dataset.match) {
                const target = document.getElementById(field.dataset.match);
                if (target && field.value !== target.value) {
                    msg = 'Hasła muszą być identyczne.';
                }
            }

            field.classList.toggle('is-invalid', !!msg);
            if (errorEl) { errorEl.textContent = msg; errorEl.style.display = msg ? 'flex' : 'none'; }
            return !msg;
        }

        inputs.forEach(field => {
            field.addEventListener('blur', () => validateField(field));
            field.addEventListener('input', () => {
                if (field.classList.contains('is-invalid')) validateField(field);
            });
        });

        form.addEventListener('submit', e => {
            let valid = true;
            inputs.forEach(field => { if (!validateField(field)) valid = false; });
            if (!valid) { e.preventDefault(); form.querySelector('.is-invalid')?.focus(); }
        });
    });
})();

(function initAttendanceBars() {
    const bars = document.querySelectorAll('.attendance-fill');
    if (!bars.length) return;

    const io = new IntersectionObserver(entries => {
        entries.forEach(e => {
            if (e.isIntersecting) {
                e.target.style.width = e.target.dataset.pct + '%';
                io.unobserve(e.target);
            }
        });
    }, { threshold: 0.5 });

    bars.forEach(bar => {
        bar.style.width = '0';
        io.observe(bar);
    });
})();

(function initHeroParallax() {
    const heroBg = document.querySelector('.hero-bg');
    if (!heroBg) return;

    window.addEventListener('scroll', () => {
        const scrollY = window.scrollY;
        heroBg.style.transform = `translateY(${scrollY * 0.3}px)`;
    }, { passive: true });
})();

(function setActiveNavLink() {
    const path = window.location.pathname;
    document.querySelectorAll('.nav-links .nav-link').forEach(link => {
        if (link.getAttribute('href') === path || (path !== '/' && path.startsWith(link.getAttribute('href')))) {
            link.classList.add('active');
        }
    });
})();

window.showToast = function (msg, type = 'success') {
    const container = document.getElementById('toastContainer') || (() => {
        const el = document.createElement('div');
        el.id = 'toastContainer';
        el.style.cssText = 'position:fixed;bottom:2rem;right:2rem;z-index:9999;display:flex;flex-direction:column;gap:0.5rem;';
        document.body.appendChild(el);
        return el;
    })();

    const toast = document.createElement('div');
    const colors = { success: '#DCFCE7;color:#166534', danger: '#FEE2E2;color:#991B1B', info: '#DBEAFE;color:#1D4ED8' };
    toast.style.cssText = `background:${colors[type] || colors.info};border-radius:8px;padding:0.75rem 1.25rem;font-size:0.875rem;font-family:'DM Sans',sans-serif;max-width:320px;box-shadow:0 4px 20px rgba(0,0,0,0.1);animation:fadeIn 0.3s ease;`;
    toast.textContent = msg;
    container.appendChild(toast);

    setTimeout(() => { toast.style.opacity = '0'; toast.style.transition = 'opacity 0.3s'; setTimeout(() => toast.remove(), 300); }, 4000);
};

document.querySelectorAll('[data-confirm]').forEach(el => {
    el.addEventListener('click', e => {
        if (!confirm(el.dataset.confirm || 'Czy na pewno chcesz wykonać tę akcję?')) {
            e.preventDefault();
        }
    });
});

(function initMiniCalendar() {
    const cal = document.getElementById('miniCalendar');
    if (!cal) return;

    const now = new Date();
    let year = now.getFullYear();
    let month = now.getMonth();

    const eventDates = JSON.parse(cal.dataset.events || '[]');

    function render() {
        const firstDay = new Date(year, month, 1).getDay();
        const daysInMonth = new Date(year, month + 1, 0).getDate();
        const monthNames = ['Styczeń', 'Luty', 'Marzec', 'Kwiecień', 'Maj', 'Czerwiec', 'Lipiec', 'Sierpień', 'Wrzesień', 'Październik', 'Listopad', 'Grudzień'];

        let html = `<div style="display:flex;justify-content:space-between;align-items:center;margin-bottom:0.75rem;">
      <button onclick="window._calPrev()" style="background:none;border:none;cursor:pointer;font-size:1rem;color:var(--clr-gold)">&#8249;</button>
      <span style="font-family:var(--font-display);font-size:1rem;">${monthNames[month]} ${year}</span>
      <button onclick="window._calNext()" style="background:none;border:none;cursor:pointer;font-size:1rem;color:var(--clr-gold)">&#8250;</button>
    </div>
    <table class="mini-calendar"><thead><tr>
      <th>Pn</th><th>Wt</th><th>Śr</th><th>Cz</th><th>Pt</th><th>Sb</th><th>Nd</th>
    </tr></thead><tbody><tr>`;

        const startDay = (firstDay + 6) % 7;
        for (let i = 0; i < startDay; i++) html += '<td></td>';

        for (let d = 1; d <= daysInMonth; d++) {
            const dateStr = `${year}-${String(month + 1).padStart(2, '0')}-${String(d).padStart(2, '0')}`;
            const hasEvent = eventDates.includes(dateStr);
            const isToday = d === now.getDate() && month === now.getMonth() && year === now.getFullYear();
            html += `<td class="${hasEvent ? 'has-event' : ''} ${isToday ? 'today' : ''}" title="${hasEvent ? 'Wydarzenie' : ''}">${d}</td>`;
            if ((startDay + d) % 7 === 0 && d < daysInMonth) html += '</tr><tr>';
        }

        html += '</tr></tbody></table>';
        cal.innerHTML = html;
    }

    window._calPrev = () => { if (month === 0) { month = 11; year--; } else month--; render(); };
    window._calNext = () => { if (month === 11) { month = 0; year++; } else month++; render(); };
    render();
})();
