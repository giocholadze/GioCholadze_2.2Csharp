// Site-wide JavaScript functionality
document.addEventListener("DOMContentLoaded", () => {
    // Theme Management
    class ThemeManager {
        constructor() {
            this.currentTheme = localStorage.getItem("theme") || "light"
            this.themeToggle = document.getElementById("themeToggle")
            this.sunIcon = document.getElementById("sunIcon")
            this.moonIcon = document.getElementById("moonIcon")

            this.init()
        }

        init() {
            this.setTheme(this.currentTheme)

            if (this.themeToggle) {
                this.themeToggle.addEventListener("click", () => {
                    this.toggleTheme()
                })
            }
        }

        setTheme(theme) {
            this.currentTheme = theme
            document.documentElement.setAttribute("data-theme", theme)
            localStorage.setItem("theme", theme)

            if (this.sunIcon && this.moonIcon) {
                if (theme === "dark") {
                    this.sunIcon.style.display = "none"
                    this.moonIcon.style.display = "inline-block"
                } else {
                    this.sunIcon.style.display = "inline-block"
                    this.moonIcon.style.display = "none"
                }
            }
        }

        toggleTheme() {
            const newTheme = this.currentTheme === "light" ? "dark" : "light"
            this.setTheme(newTheme)
            this.addToggleEffect()
        }

        addToggleEffect() {
            if (this.themeToggle) {
                this.themeToggle.style.transform = "scale(0.9) rotate(180deg)"
                setTimeout(() => {
                    this.themeToggle.style.transform = "scale(1) rotate(0deg)"
                }, 200)
            }
        }
    }

    // Mobile Menu Management
    class MobileMenuManager {
        constructor() {
            this.menuToggle = document.getElementById("mobileMenuToggle")
            this.menuOverlay = document.getElementById("mobileNavOverlay")
            this.hamburgerIcon = document.querySelector(".hamburger-icon")
            this.closeIcon = document.querySelector(".close-icon")
            this.mobileNavLinks = document.querySelectorAll(".mobile-nav-link")

            this.init()
        }

        init() {
            if (this.menuToggle) {
                this.menuToggle.addEventListener("click", () => {
                    this.toggleMenu()
                })
            }

            if (this.menuOverlay) {
                this.menuOverlay.addEventListener("click", (e) => {
                    if (e.target === this.menuOverlay) {
                        this.closeMenu()
                    }
                })
            }

            // Close menu when clicking on nav links
            this.mobileNavLinks.forEach(link => {
                link.addEventListener("click", () => {
                    this.closeMenu()
                })
            })
        }

        toggleMenu() {
            if (this.menuOverlay.classList.contains("active")) {
                this.closeMenu()
            } else {
                this.openMenu()
            }
        }

        openMenu() {
            this.menuOverlay.classList.add("active")
            this.hamburgerIcon.style.display = "none"
            this.closeIcon.style.display = "inline-block"
            document.body.style.overflow = "hidden"
        }

        closeMenu() {
            this.menuOverlay.classList.remove("active")
            this.hamburgerIcon.style.display = "inline-block"
            this.closeIcon.style.display = "none"
            document.body.style.overflow = ""
        }
    }

    // League Tab Switching
    const leagueTabs = document.querySelectorAll(".league-tab")
    const leagueSections = document.querySelectorAll(".league-section")

    leagueTabs.forEach((tab) => {
        tab.addEventListener("click", function () {
            const targetLeague = this.dataset.league

            // Update active tab
            leagueTabs.forEach((t) => t.classList.remove("active"))
            this.classList.add("active")

            // Show corresponding league section
            leagueSections.forEach((section) => {
                if (section.id === `league-${targetLeague}`) {
                    section.style.display = "block"
                    // Add fade-in animation
                    section.style.opacity = "0"
                    setTimeout(() => {
                        section.style.opacity = "1"
                    }, 50)
                } else {
                    section.style.display = "none"
                }
            })
        })
    })

    // Expandable News Articles
    class ExpandableArticles {
        constructor() {
            this.expandButtons = document.querySelectorAll(".expand-btn")
            this.init()
        }

        init() {
            this.expandButtons.forEach(button => {
                button.addEventListener("click", (e) => {
                    e.preventDefault()
                    this.toggleArticle(button)
                })
            })
        }

        toggleArticle(button) {
            const newsCard = button.closest(".expandable-news-card")
            const expandableContent = newsCard.querySelector(".expandable-content")
            const expandText = button.querySelector(".expand-text")
            const expandIcon = button.querySelector(".expand-icon")

            if (expandableContent.style.display === "none" || !expandableContent.style.display) {
                // Expand
                expandableContent.style.display = "block"
                expandText.textContent = "შეკუმშვა"
                expandIcon.classList.remove("fa-chevron-down")
                expandIcon.classList.add("fa-chevron-up")
                button.classList.add("expanded")
            } else {
                // Collapse
                expandableContent.style.display = "none"
                expandText.textContent = "ვრცლად"
                expandIcon.classList.remove("fa-chevron-up")
                expandIcon.classList.add("fa-chevron-down")
                button.classList.remove("expanded")
            }
        }
    }

    // Category filtering
    document.querySelectorAll(".category-btn").forEach((btn) => {
        btn.addEventListener("click", function () {
            document.querySelectorAll(".category-btn").forEach((b) => b.classList.remove("active"))
            this.classList.add("active")

            const category = this.dataset.category
            window.SportsWebsite.filterNewsByCategory(category)
        })
    })

    // Initialize all managers
    window.themeManager = new ThemeManager()
    window.mobileMenuManager = new MobileMenuManager()
    window.expandableArticles = new ExpandableArticles()
})

// Global utility functions
window.SportsWebsite = {
    // Track news view
    trackNewsView: (articleId, currentCount) => {
        fetch("/News/IncrementViewCount", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                id: articleId,
                currentCount: currentCount,
            }),
        })
            .then((response) => response.json())
            .then((data) => {
                if (data.success) {
                    const viewCountElement = document.getElementById("viewCount")
                    if (viewCountElement) {
                        viewCountElement.textContent = data.viewCount
                    }
                }
            })
            .catch((error) => console.error("Error tracking view:", error))
    },

    // Book tickets
    bookTickets: function (matchId) {
        const button = window.event.target
        const originalContent = button.innerHTML

        button.innerHTML = '<i class="fas fa-spinner fa-spin me-2"></i>Processing...'
        button.disabled = true

        setTimeout(() => {
            button.innerHTML = originalContent
            button.disabled = false
            this.showNotification("Ticket booking system would be integrated here!", "info")
        }, 2000)
    },

    // Show notification
    showNotification: (message, type = "info") => {
        const notification = document.createElement("div")
        notification.className = `alert alert-${type} alert-dismissible fade show position-fixed`
        notification.style.cssText = "top: 20px; right: 20px; z-index: 9999; min-width: 300px;"
        notification.innerHTML = `
            ${message}
            <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
        `

        document.body.appendChild(notification)

        setTimeout(() => {
            if (notification.parentNode) {
                notification.remove()
            }
        }, 5000)
    },

    // Filter news by category
    filterNewsByCategory: (category) => {
        const newsCards = document.querySelectorAll(".news-card")

        newsCards.forEach((card) => {
            const cardCategory = card.dataset.category

            if (category === "All" || cardCategory === category) {
                card.style.display = "block"
                card.classList.add("fade-in")
            } else {
                card.style.display = "none"
                card.classList.remove("fade-in")
            }
        })
    },

    // Show news modal
    showNewsModal: () => {
        const modal = new bootstrap.Modal(document.getElementById("newsModal"))
        modal.show()
    },

    // Share article
    shareArticle: (platform) => {
        const url = window.location.href
        const title = document.title

        let shareUrl = ""
        switch (platform) {
            case "facebook":
                shareUrl = `https://www.facebook.com/sharer/sharer.php?u=${encodeURIComponent(url)}`
                break
            case "twitter":
                shareUrl = `https://twitter.com/intent/tweet?url=${encodeURIComponent(url)}&text=${encodeURIComponent(title)}`
                break
            case "whatsapp":
                shareUrl = `https://wa.me/?text=${encodeURIComponent(title + " " + url)}`
                break
        }

        if (shareUrl) {
            window.open(shareUrl, "_blank", "width=600,height=400")
        }
    },
}